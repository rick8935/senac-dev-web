import { Component, Input } from '@angular/core';
import { Categorias } from '../../../pages/categorias/categorias';

@Component({
  selector: 'app-status-badge',
  imports: [],
  templateUrl: './status-badge.html',
  styleUrl: './status-badge.css',
})
export class StatusBadge {
  @Input() status: boolean = true;
}
