import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/services';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  providers: [ProductService]
})
export class ProductComponent {

  constructor(productService: ProductService) {

  }

}
