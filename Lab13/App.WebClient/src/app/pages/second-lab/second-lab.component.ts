import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, FormArray, Validators, ReactiveFormsModule} from '@angular/forms';
import {ApiService} from "../../api.service";
import {NgForOf, NgIf} from "@angular/common";

@Component({
  selector: 'app-second-lab',
  templateUrl: './second-lab.component.html',
  standalone: true,
  imports: [
    NgIf,
    ReactiveFormsModule,
    NgForOf
  ]
})
export class SecondLabComponent implements OnInit {
  secondLabForm!: FormGroup;
  result: number | null = null;
  errorMessage: string = '';

  constructor(private fb: FormBuilder, private apiService: ApiService) {}

  ngOnInit(): void {
    this.secondLabForm = this.fb.group({
      totalSocks: ['', [Validators.required, Validators.min(1)]],
      supplierCount: ['', [Validators.required, Validators.min(1)]],
      suppliers: this.fb.array([]) // Використовуємо FormArray для постачальників
    });
  }

  get suppliers(): FormArray {
    return this.secondLabForm.get('suppliers') as FormArray;
  }

  updateSuppliers(count: number): void {
    while (this.suppliers.length !== 0) {
      this.suppliers.removeAt(0);
    }

    for (let i = 0; i < count; i++) {
      this.suppliers.push(
        this.fb.group({
          packs: ['', [Validators.required, Validators.min(1)]],
          price: ['', [Validators.required, Validators.min(1)]]
        })
      );
    }
  }

  useExample(): void {
    this.secondLabForm.patchValue({
      totalSocks: 9,
      supplierCount: 2
    });
    this.updateSuppliers(2);
    this.suppliers.at(0).patchValue({ packs: 1, price: 1 });
    this.suppliers.at(1).patchValue({ packs: 10, price: 8 });
  }

  submitForm(): void {
    if (this.secondLabForm.valid) {
      console.log(this.secondLabForm.value);
      this.apiService.solveLab2(this.secondLabForm.value).subscribe(
        (response) => {
          this.result = response
        },
        (error) => {
          this.errorMessage = error.error?.error || 'An error occurred';
        }
      );
    }
  }
}
