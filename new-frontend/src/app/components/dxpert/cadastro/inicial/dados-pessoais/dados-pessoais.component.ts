import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dados-pessoais',
  templateUrl: './dados-pessoais.component.html',
  styleUrls: ['./dados-pessoais.component.scss'], // Agora referenciado como SCSS
})
export class DadosPessoaisComponent implements OnInit {
  @Input() id: string | undefined; // Recebe o ID para busca
  form!: FormGroup; // Formulário reativo
  err: string = ''; // Mensagem de erro, inicializada como string vazia

  constructor(private fb: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    // Inicializa o formulário
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      celular: ['', [Validators.required]],
      nome: ['', Validators.required],
      dataNascimento: ['', Validators.required],
      sexo: ['', Validators.required],
    });

    // Se houver um ID, simula a busca de dados do backend
    if (this.id) {
      this.mockBackendFetch(this.id);
    }
  }

  enviar(): void {
    if (this.form.valid) {
      // Simula o envio dos dados
      console.log('Enviando dados...', this.form.value);
      // Redireciona para outra página após o envio (simulado)
      this.router.navigate(['/sucesso']);
    } else {
      this.err = 'Por favor, preencha todos os campos obrigatórios.';
    }
  }

  // Simula a busca dos dados com base no ID
  private mockBackendFetch(id: string): void {
    console.log(`Buscando dados para o ID: ${id}`);
    // Simula um retorno do backend
    setTimeout(() => {
      const mockData = {
        email: 'usuario@example.com',
        celular: '(11) 98765-4321',
        nome: 'Usuário Simulado',
        dataNascimento: '1990-01-01',
        sexo: 1, // 1 = Feminino, 0 = Masculino
      };
      // Atualiza o formulário com os dados simulados
      this.form.patchValue(mockData);
    }, 1000); // Simula tempo de resposta do backend
  }
}
