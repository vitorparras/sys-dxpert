import { CurrencyPipe } from '@angular/common';
import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { ChartDataset } from 'chart.js';
import { Chart, ChartOptions, ChartType, registerables } from 'chart.js';
import { Label } from 'chartist';
import ChartDataLabels from 'chartjs-plugin-datalabels';
import { SharedService } from 'src/app/services/shared.service';

Chart.register(...registerables, ChartDataLabels);

@Component({
  selector: 'app-relatorio-percas',
  templateUrl: './relatorio-percas.component.html',
  styleUrls: ['./relatorio-percas.component.css'],
})
export class RelatorioPercasComponent {
  @Input() relatorio: any;

  constructor(private sharedService: SharedService) {}

  formatarParaReal(valor: number): string | null {
    return this.sharedService.formatarParaReal(valor);
  }

  limpaValor(valor: any): number {
    return Number(valor.replace(/[^0-9,-]+/g, '').replace(',', '.'));
  }

  public barChartOptions: ChartOptions = {
    responsive: true,
    plugins: {
      datalabels: {
        color: '#000000',
        anchor: 'end',
        align: 'start',
        offset: -20,
        formatter: function (value, context) {
          return value.toLocaleString('pt-BR', {
            style: 'currency',
            currency: 'BRL',
          });
        },
      },
    },
  };

  public barChartLabels: Label[] = [
    'Renda',
    'Despesa',
    'Na Aposentadoria',
    'Na invalidez',
    'Pensão por morte',
  ];
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
