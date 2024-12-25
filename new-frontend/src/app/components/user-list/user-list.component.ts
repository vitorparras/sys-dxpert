import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { UserService, User } from '../../services/user.service';
import { UserDialogComponent } from '../user-dialog/user-dialog.component';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';
import { UserMetricsModalComponent } from '../user-metrics-modal/user-metrics-modal.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  displayedColumns: string[] = ['avatar', 'name', 'email', 'phone', 'role', 'actions'];
  dataSource!: MatTableDataSource<User>;
  users: User[] = [];
  isLoading = true;
  viewMode: 'table' | 'card' = 'table';

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private userService: UserService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.isLoading = true;
    this.userService.getUsers().subscribe(users => {
      this.users = users;
      this.dataSource = new MatTableDataSource(users);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      this.isLoading = false;
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openUserDialog(user?: User) {
    const dialogRef = this.dialog.open(UserDialogComponent, {
      width: '400px',
      data: user || {}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        if (result.id) {
          this.userService.updateUser(result).subscribe(() => {
            this.loadUsers();
            this.showSnackbar('Usuário atualizado com sucesso!');
          });
        } else {
          this.userService.addUser(result).subscribe(() => {
            this.loadUsers();
            this.showSnackbar('Usuário adicionado com sucesso!');
          });
        }
      }
    });
  }

  deleteUser(id: number) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '400px',
      data: { 
        title: 'Confirmar Exclusão',
        message: 'Tem certeza que deseja excluir este usuário?',
        confirmText: 'Excluir',
        cancelText: 'Cancelar'
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.userService.deleteUser(id).subscribe(() => {
          this.loadUsers();
          this.showSnackbar('Usuário excluído com sucesso!');
        });
      }
    });
  }

  openMetrics(user: User) {
    this.dialog.open(UserMetricsModalComponent, {
      width: '900px',
      data: { user },
      panelClass: 'metrics-modal'
    });
  }

  toggleView() {
    this.viewMode = this.viewMode === 'table' ? 'card' : 'table';
  }

  private showSnackbar(message: string) {
    this.snackBar.open(message, 'Fechar', {
      duration: 3000,
      horizontalPosition: 'right',
      verticalPosition: 'top'
    });
  }

  getAvatarUrl(name: string): string {
    return `https://ui-avatars.com/api/?name=${encodeURIComponent(name)}&background=random&color=fff`;
  }
}

