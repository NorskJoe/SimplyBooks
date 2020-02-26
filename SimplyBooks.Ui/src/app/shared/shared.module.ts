import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GridModule } from '@progress/kendo-angular-grid';
import { TranslateModule } from '@ngx-translate/core';



@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        GridModule,
        TranslateModule
    ],
    exports: [
        CommonModule,
        RouterModule,
        GridModule,
        TranslateModule
    ]
})
export class SharedModule { }
