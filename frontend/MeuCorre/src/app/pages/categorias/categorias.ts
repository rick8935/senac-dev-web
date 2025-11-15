import { Component, computed, inject, OnInit, signal, TemplateRef, WritableSignal } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import {
  ModalDismissReasons,
  NgbModal,
  NgbNavModule,
  NgbTooltipModule,
} from '@ng-bootstrap/ng-bootstrap';
import { IconAvatar } from '../../shared/components/icon-avatar/icon-avatar';
import { StatusBadge } from '../../shared/components/status-badge/status-badge';
import { CategoriaModel } from './models/categoria.model';
import { CategoriaService } from './categoria.service';

@Component({
  selector: 'app-categorias',
  imports: [NgbNavModule, IconAvatar, StatusBadge, ReactiveFormsModule, NgbTooltipModule],
  templateUrl: './categorias.html',
  styleUrl: './categorias.css',
})
export class Categorias implements OnInit  {

  private modalService = inject(NgbModal);
  private categoriaService = inject(CategoriaService);

  closeResult: WritableSignal<string> = signal('');

  nome = new FormControl('');
  descricao = new FormControl('');
  cor = new FormControl('');
  icone = new FormControl('');
  tipo = new FormControl('despesa');

  active = 1;
  editandoCategoria = false;
  idEditandoCategoria = '';

  listaCategorias = signal<CategoriaModel[]>([]);

  listaReceitas = computed(() => this.listaCategorias().filter((c) => c.tipo === 'receita'));
  listaDespesas = computed(() => this.listaCategorias().filter((c) => c.tipo === 'despesa'));

  ngOnInit(): void {
    this.carregarCategorias();
  }


  carregarCategorias(){
    this.categoriaService.obterTodasPorUsuario().subscribe({
      next:(dados) => {
        const categoriasMapeadas = dados.map((c) => {
          const item: CategoriaModel = {
            id: c.id,
            nome: c.nome,
            descricao: c.descricao,
            cor: c.cor,
            icone: c.icone,
            tipo: c.tipo === '1' ? 'receita' : 'despesa',
            ativo: c.ativo,
          };
        return item;
        });
        this.listaCategorias.set(categoriasMapeadas);
      },
      error: (err) => {
        console.error('Erro ao carregar categorias:', err);
      }
    })
  }

  open(content: TemplateRef<any>, categoria?: CategoriaModel) {
    if (categoria) {
      this.idEditandoCategoria = categoria.id;
      this.editandoCategoria = true;
      this.nome.setValue(categoria.nome);
      this.descricao.setValue(categoria.descricao);
      this.cor.setValue(categoria.cor);
      this.icone.setValue(categoria.icone);
      this.tipo.setValue(categoria.tipo);
    } else {
      this.editandoCategoria = false;
      this.nome.reset();
      this.descricao.reset('');
      this.cor.reset('');
      this.icone.reset('');
      this.tipo.setValue('despesa');
    }
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then(
      (result) => {},
      (reason) => {
        this.closeResult.set(`Dismissed ${this.getDismissReason(reason)}`);
      }
    );
  }

  private getDismissReason(reason: any): string {
    switch (reason) {
      case ModalDismissReasons.ESC:
        return 'by pressing ESC';
      case ModalDismissReasons.BACKDROP_CLICK:
        return 'by clicking on a backdrop';
      default:
        return `with: ${reason}`;
    }
  }

  cadastrarCategoria() {
    const novaCategoria: CategoriaModel = {
      id: (this.listaCategorias().length + 1).toString(),
      nome: this.nome.value ?? '',
      descricao: this.descricao.value ?? '',
      cor: this.cor.value ?? '#000000',
      icone: this.icone.value ?? 'ri-question-line',
      tipo: this.tipo.value ?? 'despesa',
      ativo: true,
    };
    this.listaCategorias.update(categorias => [...categorias, novaCategoria]);
    this.modalService.dismissAll();
  }

  excluirCategoria(id: string) {
    this.listaCategorias.update(categorias => categorias.filter(c => c.id !== id));
  }

  editarCategoria() {
    this.listaCategorias.update(categorias =>
      categorias.map(c => {
        if (c.id !== this.idEditandoCategoria) {
          return c;
        }
        const atualizado: CategoriaModel = {
          id: c.id,
          nome: this.nome.value ?? c.nome,
          descricao: this.descricao.value ?? c.descricao,
          cor: this.cor.value ?? c.cor,
          icone: this.icone.value ?? c.icone,
          tipo: this.tipo.value ?? c.tipo,
          ativo: c.ativo,
        };
        return atualizado;
      })
    );
    this.modalService.dismissAll();
  }
}