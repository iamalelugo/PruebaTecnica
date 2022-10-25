import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterService } from '../../Services/register.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent  {

  formularioRegister: FormGroup = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(6)]],
    phoneNumber: ['',[Validators.required, Validators.maxLength(10)]],
    Email: ['', [Validators.required, Validators.maxLength(50), Validators.email]],
    fecha: ['', [Validators.required]]
  });

  persona: any;

  constructor(
    private registerService : RegisterService,
    private fb: FormBuilder,
    private router: Router,
    private toastr: ToastrService) { }


    register(){
      const{name, phoneNumber, Email, fecha} = this.formularioRegister.value;
      this.registerService.createPersona({name, phoneNumber, Email, fecha})
      .subscribe(res => {
        if(res == true){
          this.persona.push(this.persona);
          this.toastr.success(name, 'Registro correcto');
        }
        else{
          console.log(res);
          this.toastr.error(res, 'Error', {
            timeOut: 4000,
            progressAnimation: 'increasing'
          });
        }
      });
    }
  }

