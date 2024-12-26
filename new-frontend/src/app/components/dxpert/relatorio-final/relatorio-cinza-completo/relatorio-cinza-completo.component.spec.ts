import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RelatorioCinzaCompletoComponent } from './relatorio-cinza-completo.component';

describe('RelatorioCinzaCompletoComponent', () => {
  let component: RelatorioCinzaCompletoComponent;
  let fixture: ComponentFixture<RelatorioCinzaCompletoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RelatorioCinzaCompletoComponent]
    });
    fixture = TestBed.createComponent(RelatorioCinzaCompletoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
