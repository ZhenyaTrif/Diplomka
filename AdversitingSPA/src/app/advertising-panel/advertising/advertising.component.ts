import { Component, OnInit } from '@angular/core';
import { AdvertisingService } from 'src/app/shared/advertising.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-advertising',
  templateUrl: './advertising.component.html',
  styleUrls: ['./advertising.component.css']
})
export class AdvertisingComponent implements OnInit {

  constructor(private service: AdvertisingService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.updateCList();
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
    this.service.formData = {
      id: 0,
      advertisingName: '',
      text: '',
      imagePath: '',
      itemPrice: '',
      advertisingCategoryId: 1
    }
  }

  onSubmit(form: NgForm){
    this.service.postAdvertising(form.value).subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success("Объявление успешно размещено.", "Одобрено.");
      },
      err => {
        console.log(err);
      }
    );
    window.location.href = "home";
  }
}
