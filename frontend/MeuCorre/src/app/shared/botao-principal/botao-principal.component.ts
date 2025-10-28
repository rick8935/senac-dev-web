import { Component, Input, input, OnInit } from '@angular/core';

@Component({
  selector: 'app-botao-principal',
  standalone:true,
  templateUrl: './botao-principal.component.html',
  styleUrls: ['./botao-principal.component.css']
})
export class BotaoPrincipalComponent implements OnInit {
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
  @Input() texto = "";
}
