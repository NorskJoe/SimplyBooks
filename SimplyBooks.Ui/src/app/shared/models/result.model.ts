export class Result {
  public errors: string[];
  public isSuccess: boolean;
  public warnings: string[];
  public hasWarnings: boolean;
}

export class ResultValue<T> extends Result {
  public value: T;
}
