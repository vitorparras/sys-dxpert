import { CurrencyPipe } from '@angular/common';
import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { ChartDataset } from 'chart.js';
import { Chart, ChartOptions, ChartType, registerables } from 'chart.js';

Chart.register(...registerables);

@Component({
  selector: 'app-relatorio-percas',
  templateUrl: './relatorio-percas.component.html',
  styleUrls: ['./relatorio-percas.component.css'],
})
export class RelatorioPercasComponent {
  @Input() relatorio: any;

  constructor() {}

  formatarParaReal(valor: number): any{
  }

  limpaValor(valor: any): number {
    return Number(valor.replace(/[^0-9,-]+/g, '').replace(',', '.'));
  }

  public barChartOptions: ChartOptions = {

  };

  
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartData: ChartDataset[] = [
    { data: [0, 0, 0, 0, 0], label: 'Valores', },
  ];

  ngOnChanges(changes: SimpleChanges) {
    if (
      changes['relatorio'] &&
      changes['relatorio'].currentValue != undefined
    ) {
      this.updateChartData();
    }
  }

  updateChartData() {
    if (this.relatorio) {
      var rendalimpa = this.limpaValor(this.relatorio.rendaHoje);
      var despesalimpa = this.limpaValor(this.relatorio.despesaTotal);

      this.barChartData = [
        {
          data: [
            rendalimpa,
            despesalimpa,
            this.limpaValor(this.relatorio.aposentadoria),
            this.limpaValor(this.relatorio.beneficioInvalidez),
            this.limpaValor(this.relatorio.pensaoPorMorte),
          ],
          label: 'Valores',
          backgroundColor: 'rgba(235, 102, 8, 0.8)'
        },
      ];
    }
  }
}
