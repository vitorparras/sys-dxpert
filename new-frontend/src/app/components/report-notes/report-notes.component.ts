import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { trigger, transition, style, animate } from '@angular/animations';

interface Note {
  id: number;
  date: Date;
  responsavel: string;
  descricao: string;
}

@Component({
  selector: 'app-report-notes',
  templateUrl: './report-notes.component.html',
  styleUrls: ['./report-notes.component.scss'],
  animations: [
    trigger('fadeIn', [
      transition(':enter', [
        style({ opacity: 0, transform: 'translateY(10px)' }),
        animate('200ms ease-out', style({ opacity: 1, transform: 'translateY(0)' })),
      ])
    ]),
    trigger('slideIn', [
      transition(':enter', [
        style({ transform: 'translateY(-20px)', opacity: 0 }),
        animate('200ms ease-out', style({ transform: 'translateY(0)', opacity: 1 }))
      ])
    ])
  ]
})
export class ReportNotesComponent implements OnInit {
  notes: Note[] = [];
  noteForm: FormGroup;
  isAddingNote = false;

  constructor(
    public dialogRef: MatDialogRef<ReportNotesComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { reportId: number },
    private fb: FormBuilder
  ) {
    this.noteForm = this.fb.group({
      descricao: ['', [Validators.required, Validators.minLength(3)]]
    });
  }

  ngOnInit() {
    // Simular carregamento de anotações
    this.notes = [
      { 
        id: 1, 
        date: new Date('2024-12-25T01:54:00'), 
        responsavel: 'João Silva', 
        descricao: 'Cliente solicitou mais informações sobre o produto.'
      },
      { 
        id: 2, 
        date: new Date('2024-12-24T01:54:00'), 
        responsavel: 'Maria Santos', 
        descricao: 'Enviado e-mail com detalhes adicionais.'
      }
    ];
  }

  onClose(): void {
    this.dialogRef.close();
  }

  toggleAddNote(): void {
    this.isAddingNote = !this.isAddingNote;
    if (this.isAddingNote) {
      setTimeout(() => {
        const textarea = document.querySelector('textarea');
        if (textarea) textarea.focus();
      }, 100);
    } else {
      this.noteForm.reset();
    }
  }

  addNote(): void {
    if (this.noteForm.valid) {
      const newNote: Note = {
        id: this.notes.length + 1,
        date: new Date(),
        responsavel: 'Usuário Atual',
        descricao: this.noteForm.get('descricao')?.value
      };
      this.notes.unshift(newNote);
      this.noteForm.reset();
      this.isAddingNote = false;
    }
  }

  getInitials(name: string): string {
    return name.split(' ')[0][0];
  }

  formatDate(date: Date): string {
    return date.toLocaleString('pt-BR', {
      day: '2-digit',
      month: '2-digit',
      year: 'numeric',
      hour: '2-digit',
      minute: '2-digit'
    });
  }
}

