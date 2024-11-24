import { Component } from '@angular/core';
import {FormsModule} from "@angular/forms";
import {ApiService} from "../../api.service";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-first-lab',
  template: `
    <h1>Lab 1: Find N-th Member</h1>
    <form (ngSubmit)="onSubmit()">
      <label for="inputNumber">Enter N:</label>
      <input type="number" [(ngModel)]="inputNumber" name="inputNumber" required/>
      <button type="submit">Calculate</button>
    </form>
    <div *ngIf="result !== null">
      <h3>Result: {{ result }}</h3>
    </div>
    <div *ngIf="errorMessage">
      <h3>Error: {{ errorMessage }}</h3>
    </div>
  `,
  imports: [
    FormsModule,
    NgIf
  ],
  standalone: true
})
export class FirstLabComponent {
  inputNumber: number = 0;
  result: number | null = null;
  errorMessage: string = '';

  constructor(private apiService: ApiService) {}

  onSubmit() {
    console.log(this.inputNumber)
    this.apiService.solveLab1(this.inputNumber).subscribe(
      (response) => {
        this.result = response
        this.errorMessage = '';
      },
      (error) => {
        this.errorMessage = error.error?.error || 'An error occurred';
        this.result = null;
      }
    );
  }
}

