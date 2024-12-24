import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Report } from '../../services/report.service';

@Component({
  selector: 'app-report-dialog',
  templateUrl: './report-dialog.component.html',
  styleUrls: ['./report-dialog.component.scss']
})
export class ReportDialogComponent {
  reportForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<ReportDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Report
  ) {
    this.reportForm = this.fb.group({
      title: [data.title || '', Validators.required],
      description: [data.description || '', Validators.required],
      date: [data.date || new Date(), Validators.required]
    });
  }

  onSubmit() {
    if (this.reportForm.valid) {
      this.dialogRef.close({
        ...this.data,
        ...this.reportForm.value
      });
    }
  }

  onCancel() {
    this.dialogRef.close();
  }
}

