import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { Router } from '@angular/router';

interface Filho {
  nome: string;
  dtNasc: string;
}

@Component({
  selector: 'app-dados-descendentes',
  templateUrl: './dados-descendentes.component.html',
  styleUrls: ['./dados-descendentes.component.css'],
})
export class DadosDescendentesComponent implements OnInit {
  form!: FormGroup;
  filhos: Filho[] = [{ nome: '', dtNasc: '' }];
  err: string = '';

  constructor(
    private fb: FormBuilder,
    private router: Router,
  ) {}

  ngOnInit() {
    this.initForm();
  }

  private initForm(): void {
    this.form = this.fb.group({
      quantidadeFilhos: ['', [Validators.required, Validators.min(0)]],
      filhosMaiores: ['', [Validators.required, Validators.min(0)]],
      etapa: 'Dados Descendentes - Filhos',
      id: [0, Validators.required],
    });
  }

  adicionarFilho(): void {
    this.filhos.push({ nome: '', dtNasc: '' });
  }

  onFocus(event: Event): void {
    (event.target as HTMLInputElement).type = 'date';
  }

  onBlur(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (!input.value) {
      input.type = 'text';
    }
  }

  enviarFormulario(): void {
    if (this.form.valid && this.filhosValidos()) {
      console.log('Formulário válido:', { ...this.form.value, filhos: this.filhos });
      this.router.navigate(['relatorio/cadastro/dados-profissionais']);

    } else {
      this.err = 'Por favor, preencha todos os campos obrigatórios corretamente.';
      this.form.markAllAsTouched();
    }
  }

  private filhosValidos(): boolean {
    return this.filhos.every(filho => filho.nome && filho.dtNasc);
  }
}

