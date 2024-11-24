import { Component } from '@angular/core';
import {FormBuilder, FormGroup, FormControl, FormArray, Validators, ReactiveFormsModule} from '@angular/forms';
import {NgForOf, NgIf} from "@angular/common";
import {ApiService} from "../../api.service";

@Component({
  selector: 'app-third-lab',
  templateUrl: './third-lab.component.html',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    NgIf,
    NgForOf
  ],
})
export class ThirdLabComponent {
  thirdLabForm: FormGroup;
  result: number | null = null;

  constructor(private fb: FormBuilder, private apiService: ApiService ) {
    this.thirdLabForm = this.fb.group({
      rows: [null, [Validators.required, Validators.min(1)]],
      cols: [null, [Validators.required, Validators.min(1)]],
      keyPrices: this.fb.group({
        R: [null, [Validators.required]],
        G: [null, [Validators.required]],
        B: [null, [Validators.required]],
        Y: [null, [Validators.required]],
      }),
      labyrinth: this.fb.array([]),
    });
  }

  get labyrinth(): FormArray {
    return this.thirdLabForm.get('labyrinth') as FormArray;
  }

  initializeLabyrinth(): void {
    const rows = this.thirdLabForm.get('rows')?.value || 0; // Отримати значення "rows"
    const cols = this.thirdLabForm.get('cols')?.value || 0;
    const labyrinthArray = new FormArray([]);
    for (let i = 0; i < rows; i++) {
      const row = new FormArray([]);
      for (let j = 0; j < cols; j++) {
        row.push(new FormControl('', Validators.required));
      }
      labyrinthArray.push(row);
    }
    this.thirdLabForm.setControl('labyrinth', labyrinthArray);
  }


  getRow(rowIndex: number): FormArray {
    return this.labyrinth.at(rowIndex) as FormArray;
  }

  onLabyrinthSizeChange(rows: number, cols: number): void {
    this.initializeLabyrinth();
  }

  useExample(): void {
    this.thirdLabForm.patchValue({
      rows: 6,
      cols: 6,
      keyPrices: { R: 1, G: 5, B: 3, Y: 1 },
    });
    this.initializeLabyrinth();
    this.labyrinth.setValue([
      ['X', 'X', 'X', 'X', 'X', 'X'],
      ['X', 'S', '.', 'X', '.', 'X'],
      ['X', '.', '.', 'R', '.', 'X'],
      ['X', '.', 'X', 'X', 'B', 'X'],
      ['X', '.', 'G', '.', 'E', 'X'],
      ['X', 'X', 'X', 'X', 'X', 'X'],
    ]);
  }
  onSubmit(): void {
    if (this.thirdLabForm.invalid) {
      console.error('Form is invalid');
      return;
    }

    const formData = this.thirdLabForm.value;
    const formattedLabyrinth = formData.labyrinth.map((row: any) =>
      row.map((cell: any) => (cell ? cell : '.'))
    );

    const payload = {
      ...formData,
      labyrinth: formattedLabyrinth,
    };

    console.log(payload);

    this.apiService.solveLab3(payload).subscribe({
      next: (result) => this.result = result,
      error: (err) => console.error('Error:', err),
    });
  }

}
