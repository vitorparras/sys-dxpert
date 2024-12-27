import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-relatorio-gerado-sucesso',
  templateUrl: './relatorio-gerado-sucesso.component.html',
  styleUrls: ['./relatorio-gerado-sucesso.component.css'],
})
export class RelatorioGeradoSucessoComponent {
  constructor(private router: Router,) {}

  submitForm() {
    setTimeout(() => {
      this.router.navigate(['/relatorio/steps/completo']);
    }, 1000);
  }

  enviarPorEmail() {
    // Implemente a lógica para enviar o relatório por e-mail
  }
}
