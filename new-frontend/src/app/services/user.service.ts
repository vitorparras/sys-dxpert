import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { delay } from 'rxjs/operators';

export interface User {
  id: number;
  name: string;
  email: string;
  phone: string;
  role: string;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private users: User[] = [
    {
      id: 1,
      name: 'John Doe',
      email: 'john@example.com',
      phone: '(11) 99999-9999',
      role: 'user'
    },
    {
      id: 2,
      name: 'Jane Smith',
      email: 'jane@example.com',
      phone: '(11) 98888-8888',
      role: 'admin'
    },
    {
      id: 3,
      name: 'Bob Johnson',
      email: 'bob@example.com',
      phone: '(11) 97777-7777',
      role: 'user'
    },
  ];

  constructor() { }

  getUsers(): Observable<User[]> {
    return of(this.users).pipe(delay(500));
  }

  getUser(id: number): Observable<User | undefined> {
    return of(this.users.find(user => user.id === id)).pipe(delay(500));
  }

  addUser(user: User): Observable<User> {
    const newUser = { ...user, id: this.users.length + 1 };
    this.users.push(newUser);
    return of(newUser).pipe(delay(500));
  }

  updateUser(user: User): Observable<User> {
    const index = this.users.findIndex(u => u.id === user.id);
    if (index !== -1) {
      this.users[index] = user;
    }
    return of(user).pipe(delay(500));
  }

  deleteUser(id: number): Observable<boolean> {
    const index = this.users.findIndex(u => u.id === id);
    if (index !== -1) {
      this.users.splice(index, 1);
      return of(true).pipe(delay(500));
    }
    return of(false).pipe(delay(500));
  }

  getCurrentUser(): Observable<User> {
    return of(this.users[0]).pipe(delay(500));
  }

  changePassword(currentPassword: string, newPassword: string): Observable<boolean> {
    // TODO: Replace with actual API call
    return of(true).pipe(delay(500));
  }
}