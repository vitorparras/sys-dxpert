import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { LoadingService } from 'src/app/services/loading.service';
import { RelatorioService } from 'src/app/services/relatorio.service';
import { localStorageVarNames } from 'src/environments/localStorageVarNames';
import { jsPDF } from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-relatorio-completo',
  templateUrl: './relatorio-completo.component.html',
  styleUrls: ['./relatorio-completo.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class RelatorioCompletoComponent {
  constructor(
    public loadingService: LoadingService,
    private router: Router,
    private _relatorioService: RelatorioService
  ) {}

  relatorio: any

  ngOnInit() {
    var idCad = localStorage.getItem(localStorageVarNames.IdCadastroAtual) ?? 1;

    this._relatorioService.getRelatorio(idCad).subscribe((res) => {
      console.log(res);
      this.relatorio = res;
    });
  }


  printPage() {
    const options = {
      filename: 'myfile.pdf',
      image: { type: 'jpeg', quality: 0.98 },
      html2canvas: { scale: 2, logging: true, dpi: 192, letterRendering: true },
      jsPDF: { unit: 'mm', format: 'a4', orientation: 'portrait' }
    };
    var content: Element | null = document.getElementById('printableArea');
  }}

