import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-gerando-relatorio',
  templateUrl: './gerando-relatorio.component.html',
  styleUrls: ['./gerando-relatorio.component.css']
})
export class GerandoRelatorioComponent {

  constructor(private router: Router) {}

  ngOnInit(): void {

    setTimeout(() => {
      this.router.navigate(['/relatorio/gerado']);
    }, 5000);

  }

  cancelar() {
    this.router.navigate(['/cadastro/dados-saude']);
  }
}
