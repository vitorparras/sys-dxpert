import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';



@Component({
  selector: 'app-relatorio-completo',
  templateUrl: './relatorio-completo.component.html',
  styleUrls: ['./relatorio-completo.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class RelatorioCompletoComponent {
  constructor(
    private router: Router,
  ) {}

  relatorio: any

  ngOnInit() {
  
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

