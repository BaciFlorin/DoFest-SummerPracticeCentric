import { Component, OnInit, OnDestroy } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  AbstractControl,
} from '@angular/forms';
import { UserService } from '../services/user.service';
import { NewPasswordModel } from '../models/newpassword.model';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss'],
})
export class UserInfoComponent implements OnInit, OnDestroy {
  public formGroup: FormGroup;
  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly userService: UserService
  ) {
    this.formGroup = this.formBuilder.group({
      newPassword: ['', [Validators.required, Validators.minLength(8)]],
      confirmPassword: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {}

  public invalidConfirmPass(): boolean {
    let pass = this.formGroup.get('newPassword').value;
    let confirmPass = this.formGroup.get('confirmPassword').value;
    return (
      this.formGroup.get('newPassword').valid &&
      this.formGroup.get('confirmPassword').valid &&
      pass != confirmPass
    );
  }

  public isInvalid(form: AbstractControl): boolean {
    return form.invalid && form.touched && form.dirty;
  }

  changePassword() {
    const pass: NewPasswordModel = {
      newPassword: this.formGroup.get('newPassword').value,
    };

    this.userService
      .changePassword(pass)
      .subscribe((response: HttpResponse<any>) => {
        if (response.status == 200) {
          document.getElementById('response').innerHTML = 'Password changed!';

          this.formGroup.reset();
        }
      }, this.handleError);
    this.formGroup.reset();
  }

  ngOnDestroy(): void {}

  private handleError(responseError: HttpErrorResponse): void {
    cleanErrorList();
    if (responseError.status == 400) {
      if ('errors' in responseError.error) {
        let errorList: Array<string> = responseError.error.errors;
        for (var error in errorList) {
          var newError = document.createElement('div');
          newError.className = 'error-item';
          newError.innerHTML = errorList[error][0];
          document.getElementById('error-list').appendChild(newError);
        }
      } else {
        var newError = document.createElement('div');
        newError.className = 'error-item';
        newError.innerHTML = responseError.error.message;
        document.getElementById('error-list').appendChild(newError);
      }
    }
  }
}

function cleanErrorList(): void {
  let errorList = document.getElementById('error-list').childNodes;
  errorList.forEach((child) => {
    document.getElementById('error-list').removeChild(child);
  });
}
