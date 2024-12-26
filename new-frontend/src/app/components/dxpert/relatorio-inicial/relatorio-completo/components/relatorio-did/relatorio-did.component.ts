import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-relatorio-did',
  templateUrl: './relatorio-did.component.html',
  styleUrls: ['./relatorio-did.component.css']
})
export class RelatorioDidComponent {
  @Input() relatorio: any;


  isMedico = true; // Substitua por um valor dinâmico conforme necessário
  valorDadosDidMedico = 0; // Substitua por um valor dinâmico conforme necessário
  valorCalculado = 'R$ 0.00'; // Substitua por um valor dinâmico conforme necessário
  somaDid = 0; // Substitua por um valor dinâmico conforme necessário

  calcularDidMedico() {
    // Implemente a lógica de cálculo aqui
  }


}
