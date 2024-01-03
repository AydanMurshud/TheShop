import axios, { AxiosRequestConfig } from "axios";
import { useEffect, useState } from "react";
const baseUrl = "https://localhost:7234";
export enum Method {
  GET = "GET",
  POST = "POST",
  PUT = "PUT",
  DELETE = "DELETE",
}
export interface IOptions {
  method: Method;
  route: string;
  id?: string;
  query?: string;
  token?: string;
}
const useAxios = ({method,route,id,query,token}:IOptions) => {
  const [data, setData] = useState<any>(null);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<any>(null);

  let options: AxiosRequestConfig = {
    method: method,
    url: baseUrl + route + (id ? `/${id}` : "") + (query ? query : ""),
  };
  if (token) {
    options.headers = {
      Authorization: `Bearer ${token}`,
    };
  }
  useEffect(() => {
    setLoading(true);
    axios(options)
      .then((res) => {
        setData(res.data);
        setLoading(false);
      })
      .catch((err) => {
        setError(err);
        setLoading(false);
      });
  }, []);

  return { data, loading, error };
}
export default useAxios;