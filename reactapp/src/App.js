import React, { Component } from 'react';
import BookComponent from './features/books/BookComponent/BookComponent';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <BookComponent></BookComponent>
        );
    }
}
