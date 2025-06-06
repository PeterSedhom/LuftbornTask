import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Viking, VikingGender, VikingRank } from '../../models/viking.model';
import { VikingService } from '../../services/viking';

@Component({
  selector: 'app-viking',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './viking.html',
  styleUrl: './viking.css'
})
export class VikingComponent implements OnInit {
  vikings: Viking[] = [];
  vikingForm: Viking = this.getEmptyViking();
  isEdit = false;

  VikingGender = VikingGender;
  VikingRank = VikingRank;
  genderOptions = Object.values(VikingGender).filter(v => typeof v === 'number');
  rankOptions = Object.values(VikingRank).filter(v => typeof v === 'number');

  constructor(private toastr: ToastrService,private vikingService: VikingService) {}

  ngOnInit() {
    this.loadVikings();
  }

  loadVikings() {
    this.vikingService.getVikings().subscribe(data => this.vikings = data);
  }

  getEmptyViking(): Viking {
    return { name: '', age: 0, gender: VikingGender.Male, rank: VikingRank.Warrior };
  }

  submitForm() {
     if (!this.vikingForm.name || this.vikingForm.name.trim().length === 0) {
      this.toastr.error('Name is required.', 'Validation Error');
      return;
    }

    if (
      !this.vikingForm.age ||
      isNaN(this.vikingForm.age) ||
     this.vikingForm.age <= 0
    ) {
      this.toastr.error('Age must be a positive number.', 'Validation Error');
      return;
    }
    if (this.isEdit && this.vikingForm.id) {
      this.vikingService.updateViking(this.vikingForm.id, this.vikingForm).subscribe(() => {
        this.loadVikings();
        this.cancelEdit();
      });
    } else {
      this.vikingService.addViking(this.vikingForm).subscribe(() => {
        this.loadVikings();
        this.vikingForm = this.getEmptyViking();
      });
    }
  }

  editViking(viking: Viking) {
    this.vikingForm = { ...viking };
    this.isEdit = true;
  }

  cancelEdit() {
    this.isEdit = false;
    this.vikingForm = this.getEmptyViking();
  }

  deleteViking(id?: string) {
    if (!id) return;
    this.vikingService.deleteViking(id).subscribe(() => this.loadVikings());
  }
}
