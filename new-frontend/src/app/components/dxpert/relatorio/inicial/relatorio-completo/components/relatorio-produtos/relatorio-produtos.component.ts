import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-relatorio-produtos',
  templateUrl: './relatorio-produtos.component.html',
  styleUrls: ['./relatorio-produtos.component.css']
})
export class RelatorioProdutosComponent {
  @Input() relatorio: any;



  produtos = [
    {Titulo: 'TERM LIFE', Porcentagem: '0', Codigo: '0', Nome: '0', Capital: 'R$ 0.00', Investimento: '0'},
    {Titulo: 'DOENÇAS GRAVES', Porcentagem: '0', Codigo: '0', Nome: '0', Capital: 'R$ 0.00', Investimento: '0'},
    {Titulo: 'INVALIDEZ MAJORADA', Porcentagem: '0', Codigo: '0', Nome: '0', Capital: 'R$ 0.00', Investimento: '0'},
  ];

  somaTotalProdutos = this.produtos.reduce((sum, produto) => sum + Number(produto.Investimento), 0);

  redirecionar() {
    // Implemente a lógica de redirecionamento aqui
  }






}
