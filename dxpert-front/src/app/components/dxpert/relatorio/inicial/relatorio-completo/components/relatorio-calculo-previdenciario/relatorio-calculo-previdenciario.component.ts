import { CurrencyPipe } from '@angular/common';
import { Component, Input } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-relatorio-calculo-previdenciario',
  templateUrl: './relatorio-calculo-previdenciario.component.html',
  styleUrls: ['./relatorio-calculo-previdenciario.component.css'],
})
export class RelatorioCalculoPrevidenciarioComponent {
  @Input() relatorio: any;

  constructor(private sharedService: SharedService) {}

  formatarParaReal(valor: any): string | null {
    return this.sharedService.formatarParaReal(valor);
  }
}
