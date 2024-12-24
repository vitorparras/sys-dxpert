import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { delay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isAuthenticated: boolean = false;
  private isAdminUser: boolean = false;

  constructor() { }

  login(email: string, password: string): Observable<boolean> {
    // Mock de autenticação
    if (email === 'user@example.com' && password === 'password') {
      this.isAuthenticated = true;
      // var teste = email == "admin@example.com";
      this.isAdminUser = true;
      return of(true).pipe(delay(1000)); // Simula delay de rede
    }
    return of(false).pipe(delay(1000));
  }

  logout(): void {
    this.isAuthenticated = false;
    this.isAdminUser = false;
  }

  isLoggedIn(): boolean {
    return this.isAuthenticated;
  }

  isAdmin(): boolean {
    return this.isAdminUser;
  }
}

