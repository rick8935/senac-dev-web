import { computeMsgId } from '@angular/compiler';
import { Component, computed, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BotaoPrincipalComponent } from "./shared/botao-principal/botao-principal.component";
import { BotaoSecundarioComponent } from "./shared/botao-secundario/botao-secundario.component";

@Component({
  selector: 'app-root',
  standalone:true,
  imports: [RouterOutlet, BotaoPrincipalComponent, BotaoSecundarioComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('MeuCorre - Finanças Pessoais');

}
