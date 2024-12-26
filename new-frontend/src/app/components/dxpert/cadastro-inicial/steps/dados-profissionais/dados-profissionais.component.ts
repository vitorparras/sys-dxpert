import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dados-profissionais',
  templateUrl: './dados-profissionais.component.html',
  styleUrls: ['./dados-profissionais.component.css'],
})
export class DadosProfissionaisComponent {
  @Input() id: string | undefined;
  err: string | undefined;
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
  ) {
    this.form = this.fb.group({
      profissao: ['', Validators.required],
      ocupacao: ['', Validators.required],
      anosContribuicao: ['', Validators.required],
      dataPosse: [''],
      regimeContratacao: ['', Validators.required],
      etapa: 'Dados Profissionais',
      id: 0,
    });
  }

  enviar() {
    if (this.form.valid) {
      console.log('Formulário válido:', this.form.value);
      this.router.navigate(['relatorio/cadastro/dados-financeiros']);

    } else {
      this.err = 'Por favor, preencha todos os campos obrigatórios corretamente.';
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

