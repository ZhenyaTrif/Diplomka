import { Component, OnInit } from '@angular/core';
import { AdvertisingService } from 'src/app/shared/advertising.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-advertising-category',
  templateUrl: './advertising-category.component.html',
  styleUrls: ['./advertising-category.component.css']
})
export class AdvertisingCategoryComponent implements OnInit {

  constructor(private service: AdvertisingService, private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm){
    if (form != null) {
      form.resetForm();
    }
    this.service.formCData = {
      id: 0,
      categoryName: ''
    }
  }

  onSubmit(form: NgForm){
    if(this.service.formCData.id == 0){
      this.insertRecord(form);
    }
    else{
      this.updateRecord(form);
    }
    window.location.href = "admin-panel";
  }

  insertRecord(form?: NgForm){
    this.service.postAdCategory().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success("Категория успешно добавлена.", "Одобрено.");
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form?: NgForm){
    this.service.putAdCategory().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success("Категория успешно изменена.", "Одобрено.");
      },
      err => {
        console.log(err);
      }
    );
  }
}
