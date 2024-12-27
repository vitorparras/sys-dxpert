import { CurrencyPipe } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-relatorio-calculo-previdenciario',
  templateUrl: './relatorio-calculo-previdenciario.component.html',
  styleUrls: ['./relatorio-calculo-previdenciario.component.css'],
})
export class RelatorioCalculoPrevidenciarioComponent {
  @Input() relatorio: any;

  constructor() {}

  formatarParaReal(valor: any): any {
    
  }
}
