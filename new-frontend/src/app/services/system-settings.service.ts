import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { delay } from 'rxjs/operators';

export interface SystemSetting {
  id: number;
  key: string;
  value: string;
  description: string;
}

@Injectable({
  providedIn: 'root'
})
export class SystemSettingsService {
  private settings: SystemSetting[] = [
    { id: 1, key: 'COMPANY_NAME', value: 'Acme Inc.', description: 'Company name used throughout the system' },
    { id: 2, key: 'SUPPORT_EMAIL', value: 'support@acme.com', description: 'Email address for customer support' },
    { id: 3, key: 'MAINTENANCE_MODE', value: 'false', description: 'Enable/disable system maintenance mode' },
  ];

  constructor() { }

  getSettings(): Observable<SystemSetting[]> {
    // TODO: Replace with actual API call
    return of(this.settings).pipe(delay(500));
  }

  getSetting(id: number): Observable<SystemSetting | undefined> {
    // TODO: Replace with actual API call
    return of(this.settings.find(setting => setting.id === id)).pipe(delay(500));
  }

  addSetting(setting: SystemSetting): Observable<SystemSetting> {
    // TODO: Replace with actual API call
    const newSetting = { ...setting, id: this.settings.length + 1 };
    this.settings.push(newSetting);
    return of(newSetting).pipe(delay(500));
  }

  updateSetting(setting: SystemSetting): Observable<SystemSetting> {
    // TODO: Replace with actual API call
    const index = this.settings.findIndex(s => s.id === setting.id);
    if (index !== -1) {
      this.settings[index] = setting;
    }
    return of(setting).pipe(delay(500));
  }

  deleteSetting(id: number): Observable<boolean> {
    // TODO: Replace with actual API call
    const index = this.settings.findIndex(s => s.id === id);
    if (index !== -1) {
      this.settings.splice(index, 1);
      return of(true).pipe(delay(500));
    }
    return of(false).pipe(delay(500));
  }
}

