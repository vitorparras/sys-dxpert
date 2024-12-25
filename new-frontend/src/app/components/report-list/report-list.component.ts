import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ReportService, Report } from '../../services/report.service';
import { ReportDialogComponent } from '../report-dialog/report-dialog.component';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ReportNotesComponent } from '../report-notes/report-notes.component';

@Component({
  selector: 'app-report-list',
  templateUrl: './report-list.component.html',
  styleUrls: ['./report-list.component.scss']
})
export class ReportListComponent implements OnInit {
  displayedColumns: string[] = ['nomeCliente', 'emailCliente', 'telefoneCliente', 'nomeResponsavel', 'etapa', 'actions'];
  dataSource!: MatTableDataSource<Report>;
  reports: Report[] = [];
  isLoading = true;
  viewMode: 'table' | 'card' = 'table';

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private reportService: ReportService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    this.loadReports();
  }

  loadReports() {
    this.isLoading = true;
    this.reportService.getReports().subscribe(reports => {
      this.reports = reports.filter(report => report.status !== 'arquivado');
      this.dataSource = new MatTableDataSource(this.reports);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      this.isLoading = false;
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openReportDialog(report?: Report) {
    const dialogRef = this.dialog.open(ReportDialogComponent, {
      width: '400px',
      data: report || {}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        if (result.id) {
          this.reportService.updateReport(result).subscribe(() => {
            this.loadReports();
            this.showSnackbar('Report updated successfully!');
          });
        } else {
          this.reportService.addReport(result).subscribe(() => {
            this.loadReports();
            this.showSnackbar('Report added successfully!');
          });
        }
      }
    });
  }

  deleteReport(id: number) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '400px',
      data: { 
        title: 'Confirm Deletion',
        message: 'Are you sure you want to delete this report?',
        confirmText: 'Delete',
        cancelText: 'Cancel'
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.reportService.deleteReport(id).subscribe(() => {
          this.loadReports();
          this.showSnackbar('Report deleted successfully!');
        });
      }
    });
  }

  toggleView() {
    this.viewMode = this.viewMode === 'table' ? 'card' : 'table';
  }

  private showSnackbar(message: string) {
    this.snackBar.open(message, 'Close', {
      duration: 3000,
      horizontalPosition: 'right',
      verticalPosition: 'top'
    });
  }

  getStatusColor(status: string): string {
    switch (status) {
      case 'published':
        return 'green';
      case 'draft':
        return 'orange';
      case 'archived':
        return 'gray';
      default:
        return 'black';
    }
  }

  openNotes(report: Report) {
    this.dialog.open(ReportNotesComponent, {
      width: '500px',
      data: { reportId: report.id }
    });
  }

  restartReport(report: Report) {
    window.open('Teste.com', '_blank');
  }

  continueReport(report: Report) {
    window.open('Teste.com', '_blank');
  }

  archiveReport(report: Report) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '400px',
      data: { 
        title: 'Confirmar Arquivamento',
        message: 'Tem certeza que deseja arquivar este relatório?',
        confirmText: 'Arquivar',
        cancelText: 'Cancelar'
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        report.status = 'arquivado';
        this.reportService.updateReport(report).subscribe(() => {
          this.reports = this.reports.filter(r => r.id !== report.id);
          this.dataSource.data = this.reports;
          this.showSnackbar('Relatório arquivado com sucesso!');
        });
      }
    });
  }
}

