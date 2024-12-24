import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { delay } from 'rxjs/operators';

export interface Report {
  id: number;
  title: string;
  description: string;
  date: Date;
}

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  private reports: Report[] = [
    { id: 1, title: 'Monthly Sales', description: 'Sales report for the current month', date: new Date() },
    { id: 2, title: 'User Activity', description: 'User engagement statistics', date: new Date() },
    { id: 3, title: 'Financial Summary', description: 'Overview of financial performance', date: new Date() },
  ];

  constructor() { }

  getReports(): Observable<Report[]> {
    // TODO: Replace with actual API call
    return of(this.reports).pipe(delay(500));
  }

  getReport(id: number): Observable<Report | undefined> {
    // TODO: Replace with actual API call
    return of(this.reports.find(report => report.id === id)).pipe(delay(500));
  }

  addReport(report: Report): Observable<Report> {
    // TODO: Replace with actual API call
    const newReport = { ...report, id: this.reports.length + 1, date: new Date() };
    this.reports.push(newReport);
    return of(newReport).pipe(delay(500));
  }

  updateReport(report: Report): Observable<Report> {
    // TODO: Replace with actual API call
    const index = this.reports.findIndex(r => r.id === report.id);
    if (index !== -1) {
      this.reports[index] = report;
    }
    return of(report).pipe(delay(500));
  }

  deleteReport(id: number): Observable<boolean> {
    // TODO: Replace with actual API call
    const index = this.reports.findIndex(r => r.id === id);
    if (index !== -1) {
      this.reports.splice(index, 1);
      return of(true).pipe(delay(500));
    }
    return of(false).pipe(delay(500));
  }
}

