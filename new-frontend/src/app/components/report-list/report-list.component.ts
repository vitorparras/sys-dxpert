import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ReportService } from '../../services/report.service';
import { ReportDialogComponent } from '../report-dialog/report-dialog.component';

@Component({
  selector: 'app-report-list',
  templateUrl: './report-list.component.html',
  styleUrls: ['./report-list.component.scss']
})
export class ReportListComponent implements OnInit {
  reports: any[] = [];
  displayedColumns: string[] = ['id', 'title', 'date', 'actions'];

  constructor(private reportService: ReportService, private dialog: MatDialog) {}

  ngOnInit() {
    this.loadReports();
  }

  loadReports() {
    this.reportService.getReports().subscribe(reports => {
      this.reports = reports;
    });
  }

  openReportDialog(report?: any) {
    const dialogRef = this.dialog.open(ReportDialogComponent, {
      width: '400px',
      data: report || {}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        if (result.id) {
          this.reportService.updateReport(result).subscribe(() => {
            this.loadReports();
          });
        } else {
          this.reportService.addReport(result).subscribe(() => {
            this.loadReports();
          });
        }
      }
    });
  }

  deleteReport(id: number) {
    if (confirm('Tem certeza que deseja excluir este relatório?')) {
      this.reportService.deleteReport(id).subscribe(() => {
        this.loadReports();
      });
    }
  }
}

