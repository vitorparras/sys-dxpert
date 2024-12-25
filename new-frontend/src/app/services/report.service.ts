import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { delay } from 'rxjs/operators';

export interface Report {
  id: number;
  nomeCliente: string;
  emailCliente: string;
  telefoneCliente: string;
  nomeResponsavel: string;
  etapa: string;
  status: 'ativo' | 'arquivado';
}

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  private reports: Report[] = [
    { 
      id: 1, 
      nomeCliente: 'João Silva', 
      emailCliente: 'joao@example.com',
      telefoneCliente: '(11) 98765-4321',
      nomeResponsavel: 'Maria Santos',
      etapa: 'Análise',
      status: 'ativo'
    },
    { 
      id: 2, 
      nomeCliente: 'Ana Oliveira', 
      emailCliente: 'ana@example.com',
      telefoneCliente: '(11) 91234-5678',
      nomeResponsavel: 'Carlos Ferreira',
      etapa: 'Proposta',
      status: 'ativo'
    },
    { 
      id: 3, 
      nomeCliente: 'Pedro Souza', 
      emailCliente: 'pedro@example.com',
      telefoneCliente: '(11) 99876-5432',
      nomeResponsavel: 'Lucia Mendes',
      etapa: 'Contrato',
      status: 'arquivado'
    },
  ];

  constructor() { }

  getReports(): Observable<Report[]> {
    return of(this.reports).pipe(delay(500));
  }

  getReport(id: number): Observable<Report | undefined> {
    return of(this.reports.find(report => report.id === id)).pipe(delay(500));
  }

  addReport(report: Report): Observable<Report> {
    const newReport = { ...report, id: this.reports.length + 1 };
    this.reports.push(newReport);
    return of(newReport).pipe(delay(500));
  }

  updateReport(report: Report): Observable<Report> {
    const index = this.reports.findIndex(r => r.id === report.id);
    if (index !== -1) {
      this.reports[index] = report;
    }
    return of(report).pipe(delay(500));
  }

  deleteReport(id: number): Observable<boolean> {
    const index = this.reports.findIndex(r => r.id === id);
    if (index !== -1) {
      this.reports.splice(index, 1);
      return of(true).pipe(delay(500));
    }
    return of(false).pipe(delay(500));
  }
}

