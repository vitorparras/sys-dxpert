import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { delay } from 'rxjs/operators';
import { SystemSetting } from '../interfaces/system-settings.interface';

@Injectable({
  providedIn: 'root'
})
export class SystemSettingsService {
  private settings: SystemSetting[] = [
    {
      id: 1,
      key: 'company_name',
      value: 'Dxpert Solutions',
      type: 'text',
      category: 'general',
      label: 'Nome da Empresa',
      description: 'Nome da empresa exibido em todo o sistema',
      required: true,
      validation: {
        pattern: '^[a-zA-Z0-9 ]{2,50}$'
      }
    },
    {
      id: 2,
      key: 'smtp_host',
      value: 'smtp.gmail.com',
      type: 'text',
      category: 'email',
      label: 'Servidor SMTP',
      description: 'Endereço do servidor SMTP para envio de emails',
      required: true
    },
    {
      id: 3,
      key: 'smtp_port',
      value: '587',
      type: 'number',
      category: 'email',
      label: 'Porta SMTP',
      description: 'Porta do servidor SMTP',
      required: true,
      validation: {
        min: 1,
        max: 65535
      }
    },
    {
      id: 4,
      key: 'maintenance_mode',
      value: 'false',
      type: 'boolean',
      category: 'general',
      label: 'Modo Manutenção',
      description: 'Ativar/desativar modo de manutenção do sistema',
      required: true
    },
    {
      id: 5,
      key: 'default_language',
      value: 'pt-BR',
      type: 'select',
      category: 'general',
      label: 'Idioma Padrão',
      description: 'Idioma padrão do sistema',
      required: true,
      options: ['pt-BR', 'en-US', 'es-ES']
    },
    {
      id: 6,
      key: 'session_timeout',
      value: '30',
      type: 'number',
      category: 'security',
      label: 'Tempo de Sessão',
      description: 'Tempo de expiração da sessão em minutos',
      required: true,
      validation: {
        min: 5,
        max: 120
      }
    },
    {
      id: 7,
      key: 'api_key',
      value: 'sk-123456789',
      type: 'text',
      category: 'integration',
      label: 'Chave da API',
      description: 'Chave de autenticação para integração com serviços externos',
      required: true
    }
  ];

  constructor() { }

  getSettings(): Observable<SystemSetting[]> {
    return of(this.settings).pipe(delay(500));
  }

  getSetting(id: number): Observable<SystemSetting | undefined> {
    return of(this.settings.find(s => s.id === id)).pipe(delay(500));
  }

  addSetting(setting: Omit<SystemSetting, 'id'>): Observable<SystemSetting> {
    const newSetting = {
      ...setting,
      id: Math.max(...this.settings.map(s => s.id)) + 1
    };
    this.settings.push(newSetting);
    return of(newSetting).pipe(delay(500));
  }

  updateSetting(setting: SystemSetting): Observable<SystemSetting> {
    const index = this.settings.findIndex(s => s.id === setting.id);
    if (index !== -1) {
      this.settings[index] = setting;
    }
    return of(setting).pipe(delay(500));
  }

  deleteSetting(id: number): Observable<boolean> {
    const index = this.settings.findIndex(s => s.id === id);
    if (index !== -1) {
      this.settings.splice(index, 1);
      return of(true).pipe(delay(500));
    }
    return of(false).pipe(delay(500));
  }
}

