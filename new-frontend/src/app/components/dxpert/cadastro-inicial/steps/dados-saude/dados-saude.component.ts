import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dados-saude',
  templateUrl: './dados-saude.component.html',
  styleUrls: ['./dados-saude.component.css']
})
export class DadosSaudeComponent {

  form!: FormGroup;
  @Input() id: string | undefined;
  baseUrl: string = '';
  err: string | undefined;

  constructor(private fb: FormBuilder,
    private router: Router,
  ) {
    this.form = this.fb.group({
      problemaSaude: ['', Validators.required],
      tomaRemedio: ['', Validators.required],
      fuma: ['', Validators.required],
      maiorPrioridade: ['', Validators.required],
      etapa: 'Dados Saude',
      id: 0,
    });
    this.baseUrl = window.location.origin;
  }

  enviar() {
    if (this.form.valid) {
      console.log('Formulário válido:', this.form.value);
      this.router.navigate(['/relatorio/steps/gerando']);
    } else {
      this.err = 'Por favor, preencha todos os campos obrigatórios.';
      this.markFormGroupTouched(this.form);
    }
  }

  private markFormGroupTouched(formGroup: FormGroup) {
    Object.values(formGroup.controls).forEach(control => {
      control.markAsTouched();
      if (control instanceof FormGroup) {
        this.markFormGroupTouched(control);
      }
    });
  }
}

