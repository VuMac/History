// src/app/edit-history-modal/edit-history-modal.component.ts
import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClassHistory } from 'app/services/api.service';

@Component({
  selector: 'app-edit-history-modal',
  templateUrl: './edit-history-modal.component.html',
  styleUrls: ['./edit-history-modal.component.scss']
})
export class EditHistoryModalComponent implements OnInit {
  @Input() history!: ClassHistory; // Dữ liệu lịch sử lớp học được truyền vào

  editForm: FormGroup;

  constructor(
    public activeModal: NgbActiveModal,
    private fb: FormBuilder
  ) {
    this.editForm = this.fb.group({
      name: ['', [Validators.required]],
      description: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    if (this.history) {
      this.editForm.patchValue({
        name: this.history.name,
        description: this.history.description
      });
    }
  }

  onSubmit() {
    if (this.editForm.valid) {
      const updatedHistory: ClassHistory = {
        ...this.history,
        ...this.editForm.value
      };
      this.activeModal.close(updatedHistory);
    }
  }
}
