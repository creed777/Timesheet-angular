import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, RequiredValidator } from '@angular/forms';

@Component({
  selector: 'app-projectsetup',
  templateUrl: './projectsetup.component.html',
  styleUrls: ['./projectsetup.component.css']
})

export class ProjectsetupComponent implements OnInit {

  constructor(private fb: FormBuilder) { }
  
  projectSetupForm = this.fb.group({
    txtName: [''],
    txtDescription: [''],
    txtEstTotalHrs: [''],
    txtEstLaborCost: [''],
    ddlStatus: [''],
    ddlClient: [''],
    chkCustomTask: [''],
    txtStartDate: [Date],
    txtEndDate: [Date]
  });

  ngOnInit(): void {
  }

  public onSubmit(): void {
    console.warn(this.projectSetupForm.value);
  }

  public popup(url: string): void {
    console.warn(url)
  }
}
