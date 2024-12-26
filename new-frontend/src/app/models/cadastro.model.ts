export interface DadosPessoais {
    nome: string;
    dataNascimento: string;
    sexo: number;
    email: string;
    celular: string;
  }
  
  export interface DadosFamiliares {
    estadoCivil: string;
    dataCasamento: string | null;
    conjugeNome: string;
    conjugeDataNasc: string | null;
    possuiFilhos: string;
  }
  
  export interface Cadastro {
    id?: number;
    etapaAtual: string;
    dadosPessoais: DadosPessoais;
    dadosFamiliares: DadosFamiliares;
  }
  