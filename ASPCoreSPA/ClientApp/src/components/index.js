import React, { useState, useEffect } from "react";
import Axios from "axios";

const Dump = () => {

    const [data, setData] = useState(null);

    useEffect(() => {
        Axios.get(`${process.env.BASE_API}user`)
            .then(({ data }) => {
                setData(data);
            });
    }, []);

    return (
        <div>
            {!data ? <p>Is loading . . . </p> : JSON.stringify(data, null, 2)}
        </div>
    )

};

export default Dump;
