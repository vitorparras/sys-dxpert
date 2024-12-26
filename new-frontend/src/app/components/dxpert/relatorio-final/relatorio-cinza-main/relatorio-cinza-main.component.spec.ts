import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RelatorioCinzaMainComponent } from './relatorio-cinza-main.component';

describe('RelatorioCinzaMainComponent', () => {
  let component: RelatorioCinzaMainComponent;
  let fixture: ComponentFixture<RelatorioCinzaMainComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RelatorioCinzaMainComponent]
    });
    fixture = TestBed.createComponent(RelatorioCinzaMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
