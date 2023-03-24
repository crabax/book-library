import React, { useEffect, useState } from 'react';
import bookService from './service';
import { PaginationControl } from 'react-bootstrap-pagination-control';

const BookComponent = () => {
  const pageSize = 5;
  const defaultState = { books: [], pageCount: 0, loading: true };
  const [state, setState] = useState(defaultState);  
  const [currentPage, setCurrentPage] = useState(1);  
  const [form, setForm] = useState({
    filter:  "",
    searchBy:  "",
})

  const resetSearch = () => {
    setState(defaultState);
  }

  const setFormValues = ({ name, value }) => {
    setForm({ ...form, [name]: value });
    setCurrentPage(currentPage);
  }

  const sendForm = () => {
    resetSearch();
    doSearch(1);
  }

  const paginate = async (page, form) => {
    const booksResult = await bookService.getList({...form, page: page, pageSize });
    const { items: books, totalCount } = booksResult;
    const pageCount = Math.ceil(booksResult.totalCount / pageSize);
    return { books, pageCount, totalCount };
  };

  const doSearch = async (page) => {
    const searchResult = await paginate(page, form);
    setState({
      books: searchResult.books,
      pageCount: searchResult.pageCount,
      totalCount: searchResult.totalCount,
      loading: false,
    });
  }

  useEffect(() => {
    doSearch(currentPage);
  }, [currentPage])
  

  return (
    <>
    {state.loading ? <div className="d-flex justify-content-center">
    <div className="spinner-border text-warning" role="status">
      <span className="visually-hidden">Loading...</span>
    </div>
  </div> : <div>
  <div className="mb-3">
      <h1 id="tabelLabel">Royal Library</h1>
      <p>Your best and more complete book library database. Feel free to search the books you want.</p>
  </div>
  <div className="mb-3 d-flex align-items-center">
      <label className="me-2 w-auto">Search By</label>
      <select value={form.searchBy} style={{maxWidth:'150px'}} className="form-select me-2" aria-label="SearchBy Select" onChange={e => setFormValues({ name: 'searchBy', value: e.target.value })}>
        <option value="">Everything</option>
        <option value="Authors">Authors</option>
        <option value="ISBN">ISBN</option>
        <option value="Type">Type</option>
      </select>
      
        <input value={form.filter} onChange={e => setFormValues({ name: 'filter', value: e.target.value })} className="form-control me-2" style={{maxWidth:'300px'}} type="search" placeholder="Type here..." aria-label="Search" />
        <button onClick={sendForm} className="btn btn-primary" type="submit">Search</button>
  </div>
    <table className="table">
    <thead className="table-dark">
      <tr>
        <th scope="col">Book Title</th>
        <th scope="col">Publisher</th>
        <th scope="col">Authors</th>
        <th scope="col">Type</th>
        <th scope="col">ISBN</th>
        <th scope="col">Category</th>
        <th scope="col">Available Copies</th>
      </tr>
    </thead>
    <tbody>
    {state.books.map(book => <tr  key={book.id}>
        <td>{book.title}</td>
        <td>{book.publisher}</td>
        <td>{book.authors}</td>
        <td>{book.type}</td>
        <td>{book.isbn}</td>
        <td>{book.category}</td>
        <td>{book.availableCopies}</td>
      </tr>
      )}
    </tbody>
  </table>
  <div className="d-flex align-items-baseline justify-content-end">
    <span className="me-2">Total: {state.totalCount}</span>
    <PaginationControl
      page={currentPage}
      total={state.totalCount}
      limit={pageSize}
      changePage={(page) => {
        setCurrentPage(page)
      }}
      ellipsis={1}
    />
  </div>
  </div>

    }
  </>
)};

BookComponent.propTypes = {};

BookComponent.defaultProps = {};

export default BookComponent;
