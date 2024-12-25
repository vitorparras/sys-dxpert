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
  isEditMode: boolean;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<ReportDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Report
  ) {
    this.isEditMode = !!data.id;
    this.reportForm = this.fb.group({
      nomeCliente: [data.nomeCliente || '', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      emailCliente: [data.emailCliente || '', [Validators.required, Validators.email]],
      telefoneCliente: [data.telefoneCliente || '', [Validators.required, Validators.pattern(/^$$\d{2}$$\s\d{5}-\d{4}$/)]],
      nomeResponsavel: [data.nomeResponsavel || '', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      etapa: [data.etapa || '', Validators.required],
      status: [data.status || 'ativo', Validators.required]
    });
  }

  onSubmit() {
    if (this.reportForm.valid) {
      this.dialogRef.close({
        ...this.data,
        ...this.reportForm.value
      });
    } else {
      this.reportForm.markAllAsTouched();
    }
  }

  onCancel() {
    this.dialogRef.close();
  }

  getErrorMessage(controlName: string): string {
    const control = this.reportForm.get(controlName);
    if (control?.hasError('required')) {
      return 'Este campo é obrigatório';
    }
    if (control?.hasError('minlength')) {
      return `O tamanho mínimo é ${control.errors?.['minlength'].requiredLength} caracteres`;
    }
    if (control?.hasError('maxlength')) {
      return `O tamanho máximo é ${control.errors?.['maxlength'].requiredLength} caracteres`;
    }
    if (control?.hasError('email')) {
      return 'Email inválido';
    }
    if (control?.hasError('pattern')) {
      return 'Formato inválido. Use (XX) XXXXX-XXXX';
    }
    return '';
  }
}

