import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-relatorio-sugestao-para-recuperar',
  templateUrl: './relatorio-sugestao-para-recuperar.component.html',
  styleUrls: ['./relatorio-sugestao-para-recuperar.component.css'],
})
export class RelatorioSugestaoParaRecuperarComponent {
  @Input() relatorio: any;
  somaTotal: number = 0;

  convertValor(valor: any): number {
    return Number(valor.replace(/[^0-9,-]+/g, '').replace(',', '.'));
  }

  somaValores(): number {
    this.somaTotal = 0;
    this.relatorio?.produtosSugestaoParaRecuperar.forEach((element: any) => {
      this.somaTotal += this.convertValor(element.valor2);
    });

    return this.somaTotal;
  }
}
