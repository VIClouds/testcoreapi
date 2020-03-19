import React, { Component } from 'react';
import { PhoneForm } from './PhoneForm';
import { Phone } from './Phone';



export class PhoneList extends React.Component {

    constructor(props) {
        super(props);
        this.state = { phones: [] };

        this.onAddPhone = this.onAddPhone.bind(this);
        this.onRemovePhone = this.onRemovePhone.bind(this);
    }
    
    componentDidMount() {
        this.loadData();
    }


    // загрузка данных
    loadData() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ phones: data });
        }.bind(this);
        xhr.send();
    }

    // добавление объекта
    onAddPhone(phone) {
        if (phone) {

            const data = new FormData();
            data.append("name", phone.name);
            data.append("price", phone.price);

            var xhr = new XMLHttpRequest();

            xhr.open("post", this.props.apiUrl, true);
            xhr.onload = function () {
                if (xhr.status === 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send(data);
        }
    }
    // удаление объекта
    onRemovePhone(phone) {

        if (phone) {
            var url = this.props.apiUrl + "/" + phone.id;

            var xhr = new XMLHttpRequest();
            xhr.open("delete", url, true);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.onload = function () {
                if (xhr.status === 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send();
        }
    }
    render() {

        var remove = this.onRemovePhone;
        return (
            <div>
                <PhoneForm onPhoneSubmit={this.onAddPhone} />
                <h2>Список смартфонов</h2>
                <div>
                    {
                        this.state.phones.map(function (phone) {

                            return <Phone key={phone.id} phone={phone} onRemove={remove} />
                        })
                    }
                </div>
            </div>
            );
    }
}