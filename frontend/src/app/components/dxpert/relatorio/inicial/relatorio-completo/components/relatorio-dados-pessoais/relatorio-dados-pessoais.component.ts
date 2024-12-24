import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-relatorio-dados-pessoais',
  templateUrl: './relatorio-dados-pessoais.component.html',
  styleUrls: ['./relatorio-dados-pessoais.component.css']
})
export class RelatorioDadosPessoaisComponent {
  @Input() relatorio: any;
}
