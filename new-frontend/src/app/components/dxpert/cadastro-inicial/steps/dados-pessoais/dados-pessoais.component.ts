import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dados-pessoais',
  templateUrl: './dados-pessoais.component.html',
  styleUrls: ['./dados-pessoais.component.css'],
})
export class DadosPessoaisComponent implements OnInit {
  form!: FormGroup;
  err: string = '';

  constructor(private fb: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.form = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3)]],
      dataNascimento: ['', [Validators.required]],
      sexo: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      celular: ['', [Validators.required]],
    });
  }

  enviar(): void {
    if (this.form.valid) {
      console.log('Enviando dados...', this.form.value);
      this.router.navigate(['relatorio/cadastro/dados-familiares']);
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

