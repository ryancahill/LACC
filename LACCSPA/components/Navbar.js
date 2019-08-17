import Link from 'next/link';

const Navbar = () => (
  <nav className="navbar navbar-expand navbar-dark bg-dark mb-4">
    <div className="container">
      <a className="navbar-brand" href="#">Los Angeles Cigar Club</a>
      <div className="collapse navbar-collapse">
        <ul className="navbar-nav ml-auto">
          <li className="nav-item">
            <Link href="/"><a className="nav-link">Products</a></Link>
          </li>
          <li className="nav-item">
            <Link href="/add"><a className="nav-link">Create</a></Link>
          </li>
        </ul>
      </div>
    </div>
  </nav>
);

export default Navbar;