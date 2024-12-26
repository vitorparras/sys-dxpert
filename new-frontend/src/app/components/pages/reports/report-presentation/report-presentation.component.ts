import { Component, OnInit, ElementRef, ViewChild, Output, EventEmitter, AfterViewInit, OnDestroy, Inject } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';
import { DOCUMENT } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-report-presentation',
  templateUrl: './report-presentation.component.html',
  styleUrls: ['./report-presentation.component.scss'],
  animations: [
    trigger('fadeInOut', [
      state('void', style({ opacity: 0, transform: 'translateY(20px)' })),
      transition('void <=> *', animate('500ms cubic-bezier(0.35, 0, 0.25, 1)')),
    ])
  ]
})
export class ReportPresentationComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('canvas', { static: true }) canvasRef!: ElementRef<HTMLCanvasElement>;
  @Output() startReport = new EventEmitter<void>();
  @Output() closePresentation = new EventEmitter<void>();

  private ctx!: CanvasRenderingContext2D;
  private animationFrameId!: number;

  isLoading = false;
  progress = 0;
  constructor(@Inject(DOCUMENT) private document: Document, private router: Router) {}

  ngOnInit() {
    this.addBodyClass();
  }

  ngAfterViewInit() {
    this.initCanvas();
    this.animate();
  }

  ngOnDestroy() {
    this.removeBodyClass();
    cancelAnimationFrame(this.animationFrameId);
  }

  private initCanvas() {
    const canvas = this.canvasRef.nativeElement;
    this.ctx = canvas.getContext('2d')!;

    canvas.width = window.innerWidth;
    canvas.height = window.innerHeight;

    window.addEventListener('resize', this.onWindowResize.bind(this));
  }

  private onWindowResize() {
    const canvas = this.canvasRef.nativeElement;
    canvas.width = window.innerWidth;
    canvas.height = window.innerHeight;
  }

  private animate() {
    this.ctx.clearRect(0, 0, this.ctx.canvas.width, this.ctx.canvas.height);
    
    const time = Date.now() * 0.001;
    this.drawWaves(time);

    this.animationFrameId = requestAnimationFrame(this.animate.bind(this));
  }

  private drawWaves(time: number) {
    const width = this.ctx.canvas.width;
    const height = this.ctx.canvas.height;

    for (let i = 0; i < 3; i++) {
      this.ctx.beginPath();
      this.ctx.moveTo(0, height);

      for (let x = 0; x < width; x++) {
        const y = Math.sin(x * 0.01 + time + i * 2) * 20 + height / 2;
        this.ctx.lineTo(x, y);
      }

      this.ctx.lineTo(width, height);
      this.ctx.closePath();

      const alpha = 0.1 - i * 0.03;
      this.ctx.fillStyle = `rgba(255, 107, 0, ${alpha})`;
      this.ctx.fill();
    }
  }

  onStartClick() {
    this.isLoading = true;
    document.body.style.overflow = 'hidden';
    const interval = setInterval(() => {
      this.progress += 1;
      if (this.progress >= 100) {
        clearInterval(interval);
        this.isLoading = false;
        document.body.style.overflow = '';
        //this.startReport.emit();

        //relatorio/dados-pessoais

        this.router.navigate(['/relatorio/cadastro/dados-pessoais']);

      }
    }, 30);
  }

  onBackClick() {
    this.removeBodyClass();
    this.closePresentation.emit();
  }

  private addBodyClass() {
    this.document.body.classList.add('report-presentation-active');
  }

  private removeBodyClass() {
    this.document.body.classList.remove('report-presentation-active');
  }
}

