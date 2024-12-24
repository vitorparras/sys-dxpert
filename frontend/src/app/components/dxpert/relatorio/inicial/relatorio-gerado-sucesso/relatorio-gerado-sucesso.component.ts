import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoadingService } from 'src/app/services/loading.service';

@Component({
  selector: 'app-relatorio-gerado-sucesso',
  templateUrl: './relatorio-gerado-sucesso.component.html',
  styleUrls: ['./relatorio-gerado-sucesso.component.css'],
})
export class RelatorioGeradoSucessoComponent {
  constructor(private router: Router,
    public loadingService: LoadingService,) {}

  submitForm() {
    this.loadingService.show();
    setTimeout(() => {
      this.loadingService.hide();
      this.router.navigate(['/relatorioCompleto']);
    }, 1000);
  }

  enviarPorEmail() {
    // Implemente a lógica para enviar o relatório por e-mail
  }
}
