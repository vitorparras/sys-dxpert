import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Cadastro, DadosFamiliares, DadosPessoais } from '../models/cadastro.model';

@Injectable({
  providedIn: 'root'
})
export class CadastroService {
  private cadastro: Cadastro = {
    etapaAtual: 'dadosPessoais',
    dadosPessoais: {} as DadosPessoais,
    dadosFamiliares: {} as DadosFamiliares
  };

  atualizarDadosPessoais(dados: DadosPessoais): Observable<Cadastro> {
    this.cadastro.dadosPessoais = dados;
    this.cadastro.etapaAtual = 'dadosFamiliares';
    console.log('Dados pessoais atualizados:', this.cadastro);
    return of(this.cadastro);
  }

  atualizarDadosFamiliares(dados: DadosFamiliares): Observable<Cadastro> {
    this.cadastro.dadosFamiliares = dados;
    this.cadastro.etapaAtual = 'concluido';
    console.log('Dados familiares atualizados:', this.cadastro);
    return of(this.cadastro);
  }

  obterCadastro(): Observable<Cadastro> {
    return of(this.cadastro);
  }

  // Simula busca de dados do backend
  carregarDadosPessoais(id: string): Observable<DadosPessoais> {
    const mockData: DadosPessoais = {
      nome: 'Usuário Simulado',
      dataNascimento: '1990-01-01',
      sexo: 1,
      email: 'usuario@example.com',
      celular: '(11) 98765-4321'
    };
    return of(mockData);
  }
}
